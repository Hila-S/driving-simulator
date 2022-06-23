using UnityEngine;
using System;

public class Sun : MonoBehaviour
{
	TimeSpan sunriseTime;
	TimeSpan sunsetTime;
	// Start is called before the first frame update
	void Start()
    {
		DateTime datetime = DateTime.Now;
		string date = datetime.ToString().Split(' ')[0];
		string[] dateData = date.Split('/');
		int day = 0;
		Int32.TryParse(dateData[0], out day);
		int month = 0;
		Int32.TryParse(dateData[1], out month);
		int year = 0;
		Int32.TryParse(dateData[2], out year);


		double tsunrise, tsunset;
		// Parameters : year, month, day, latitude, longitude, sunrise, sunset 
		Sunriset.SunriseSunset(year, month, day, 31.771959, 35.217018, out tsunrise, out tsunset);
		sunriseTime = TimeSpan.FromHours(tsunrise);
		sunsetTime = TimeSpan.FromHours(tsunset);
	}

	public TimeSpan getSunriseTime()
    {
		return sunriseTime;
	}
	public TimeSpan getSunsetTime()
    {
		return sunsetTime;
    }


	public sealed class Sunriset
	{
		private Sunriset()
		{
	
		}
	
		private const double SunriseSunsetAltitude = -35d / 60d;
		private const double CivilTwilightAltitude = -6d;
		private const double NauticalTwilightAltitude = -12d;
		private const double AstronomicalTwilightAltitude = -18d;
	
        //in this function we calculate the sunrise and sunset times 
		//tsunrise is the sunrise time in seconds
		//tsunset is the sunset time in seconds 
		public static void SunriseSunset(int year, int month, int day, double lat, double lng, out double tsunrise, out double tsunset)
		{
			SunriseSunset(year, month, day, lng, lat, SunriseSunsetAltitude, true, out tsunrise, out tsunset);
		}

		//in this function we calculate the civil twilight time  
		//tsunrise is the civil twilight time at sunrise in seconds
		//tsunset is the civil twilight time at sunset in seconds
		public static void CivilTwilight(int year, int month, int day, double lat, double lng, out double tsunrise, out double tsunset)
		{
			SunriseSunset(year, month, day, lng, lat, CivilTwilightAltitude, false, out tsunrise, out tsunset);
		}

		//in this function we calculate the nautical twilight time  
		//tsunrise is the civil nautical time at sunrise in seconds
		//tsunset is the civil nautical time at sunset in seconds
		public static void NauticalTwilight(int year, int month, int day, double lat, double lng, out double tsunrise, out double tsunset)
		{
			SunriseSunset(year, month, day, lng, lat, NauticalTwilightAltitude, false, out tsunrise, out tsunset);
		}

		//in this function we calculate the astronomical twilight time  
		//tsunrise is the astronomical twilight time at sunrise in seconds
		//tsunset is the astronomical twilight time at sunset in seconds
		public static void AstronomicalTwilight(int year, int month, int day, double lat, double lng, out double tsunrise, out double tsunset)
		{
			SunriseSunset(year, month, day, lng, lat, AstronomicalTwilightAltitude, false, out tsunrise, out tsunset);
		}

		//calculates the number of days passed since 2000 Jan 0.0 
		private static long daysSince2000Jan0(int y, int m, int d)
		{
			return (367L * y - ((7 * (y + ((m + 9) / 12))) / 4) + ((275 * m) / 9) + d - 730530L);
		}
	
		//conversion factors between radians and degrees
		private const double RadDeg = 180.0 / Math.PI;
		private const double DegRad = Math.PI / 180.0;
	
		//The trig functions in degrees
		private static double sind(double x)
		{
			return Math.Sin(x * DegRad);
		}
	
		private static double cosd(double x)
		{
			return Math.Cos(x * DegRad);
		}
	
		private static double tand(double x)
		{
			return Math.Tan(x * DegRad);
		}
	
		private static double atand(double x)
		{
			return RadDeg * Math.Atan(x);
		}
	
		private static double asind(double x)
		{
			return RadDeg * Math.Asin(x);
		}
	
		private static double acosd(double x)
		{
			return RadDeg * Math.Acos(x);
		}
	
		private static double atan2d(double y, double x)
		{
			return RadDeg * Math.Atan2(y, x);
		}
	
		
		//function for sun rise/set times            
		private static int SunriseSunset(int year, int month, int day, double lon, double lat,
						 double altit, bool upper_limb, out double trise, out double tset)
		{
			double d;          //days passed since January 2000
			double sr;         //solar distance
			double sRA;        //sun's right ascension 
			double sdec;       //sun's declination
			double sradius;    //sun's apparent radius 
			double t;          //diurnal arc
			double tsouth;     //time when sun is at south
			double sidtime;    //local sidereal time
	
			int rc = 0;
	
			/* Compute d of 12h local mean solar time */
			d = daysSince2000Jan0(year, month, day) + 0.5 - lon / 360.0;
	
			/* Compute the local sidereal time of this moment */
			sidtime = revolution(GMST0(d) + 180.0 + lon);
	
			/* Compute Sun's RA, Decl and distance at this moment */
			sun_RA_dec(d, out sRA, out sdec, out sr);
	
			/* Compute time when Sun is at south - in hours UT */
			tsouth = 12.0 - rev180(sidtime - sRA) / 15.0;
	
			/* Compute the Sun's apparent radius in degrees */
			sradius = 0.2666 / sr;
	
			/* Do correction to upper limb, if necessary */
			if (upper_limb)
				altit -= sradius;
	
			//calculate "t" that the sun traverses to reach the desired altitude
			{
				double cost;
				cost = (sind(altit) - sind(lat) * sind(sdec)) /
				(cosd(lat) * cosd(sdec));
				if (cost >= 1.0) /* Sun always below altit */
				{
					rc = -1;
					t = 0.0;
				}
				else if (cost <= -1.0) /* Sun always above altit */
				{
					rc = +1;
					t = 12.0;
				}
				else
				{
					t = acosd(cost) / 15.0;   /* The diurnal arc, hours */
				}
			}
	
			/* Store rise and set times - in hours UT */
			trise = tsouth - t;
			tset = tsouth + t;
	
			return rc;
		}
	
		public static double DayLen(int year, int month, int day, double lon, double lat,
						  double altit, bool upper_limb)
		{
			double d;          /* Days since 2000 Jan 0.0 (negative before) */
			double obl_ecl;    /* Obliquity (inclination) of Earth's axis */
			double sr;         /* Solar distance, astronomical units */
			double slon;       /* True solar longitude */
			double sin_sdecl;  /* Sine of Sun's declination */
			double cos_sdecl;  /* Cosine of Sun's declination */
			double sradius;    /* Sun's apparent radius */
			double t;          /* Diurnal arc */
	
			/* Compute d of 12h local mean solar time */
			d = daysSince2000Jan0(year, month, day) + 0.5 - lon / 360.0;
	
			/* Compute obliquity of ecliptic (inclination of Earth's axis) */
			obl_ecl = 23.4393 - 3.563E-7 * d;
	
			/* Compute Sun's ecliptic longitude and distance */
			sunpos(d, out slon, out sr);
	
			/* Compute sine and cosine of Sun's declination */
			sin_sdecl = sind(obl_ecl) * sind(slon);
			cos_sdecl = Math.Sqrt(1.0 - sin_sdecl * sin_sdecl);
	
			/* Compute the Sun's apparent radius, degrees */
			sradius = 0.2666 / sr;
	
			/* Do correction to upper limb, if necessary */
			if (upper_limb)
			{
				altit -= sradius;
			}
	
			/* Compute the diurnal arc that the Sun traverses to reach */
			/* the specified altitude altit: */
			double cost = (sind(altit) - sind(lat) * sin_sdecl) / (cosd(lat) * cos_sdecl);
	
			/* Sun always below altit */
			if (cost >= 1.0)
			{
				t = 0.0;
			}
			/* Sun always above altit */
			else if (cost <= -1.0)
			{
				t = 24.0;
			}
			/* The diurnal arc, hours */
			else
			{
				t = (2.0 / 15.0) * acosd(cost);
			}
	
			return t;
		}
	
		/// <summary>
		/// Computes the Sun's ecliptic longitude and distance 
		/// at an instant given in d, number of days since
		/// 2000 Jan 0.0.  The Sun's ecliptic latitude is not
		/// computed, since it's always very near 0.
		/// </summary>
		/// <param name="d"></param>
		/// <param name="lon"></param>
		/// <param name="r"></param>
		private static void sunpos(double d, out double lon, out double r)
		{
			double M;         /* Mean anomaly of the Sun */
			double w;         /* Mean longitude of perihelion */
			/* Note: Sun's mean longitude = M + w */
			double e;         /* Eccentricity of Earth's orbit */
			double E;         /* Eccentric anomaly */
			double x, y;      /* x, y coordinates in orbit */
			double v;         /* True anomaly */
	
			/* Compute mean elements */
			M = revolution(356.0470 + 0.9856002585 * d);
			w = 282.9404 + 4.70935E-5 * d;
			e = 0.016709 - 1.151E-9 * d;
	
			/* Compute true longitude and radius vector */
			E = M + e * RadDeg * sind(M) * (1.0 + e * cosd(M));
			x = cosd(E) - e;
			y = Math.Sqrt(1.0 - e * e) * sind(E);
			r = Math.Sqrt(x * x + y * y);       /* Solar distance */
			v = atan2d(y, x);                   /* True anomaly */
			lon = v + w;                        /* True solar longitude */
			if (lon >= 360.0)
			{
				lon -= 360.0;                   /* Make it 0..360 degrees */
			}
		}
	
        //calculates the sun's coordinates and distance and given time 
		private static void sun_RA_dec(double d, out double RA, out double dec, out double r)
		{
			double lon, obl_ecl, x, y, z;
	
			/* Compute Sun's ecliptical coordinates */
			sunpos(d, out lon, out r);
	
			/* Compute ecliptic rectangular coordinates (z=0) */
			x = r * cosd(lon);
			y = r * sind(lon);
	
			/* Compute obliquity of ecliptic (inclination of Earth's axis) */
			obl_ecl = 23.4393 - 3.563E-7 * d;
	
			/* Convert to equatorial rectangular coordinates - x is unchanged */
			z = y * sind(obl_ecl);
			y = y * cosd(obl_ecl);
	
			/* Convert to spherical coordinates */
			RA = atan2d(y, x);
			dec = atan2d(z, Math.Sqrt(x * x + y * y));
		}
	
		private const double INV360 = 1.0d / 360.0d;
	
        //normalizes the angles to be within the range 0-360
		private static double revolution(double x)
		{
			return (x - 360.0 * Math.Floor(x * INV360));
		}
	
		//normalize angles to be within 180 degrees 
		private static double rev180(double x)
		{
			return (x - 360.0 * Math.Floor(x * INV360 + 0.5));
		}
	
	
		//calculates GMST0, the Greenwich Mean Sidereal Time   
		private static double GMST0(double d)
		{
			double sidtim0;
			sidtim0 = revolution((180.0 + 356.0470 + 282.9404) + (0.9856002585 + 4.70935E-5) * d);
			return sidtim0;
		}
	
	}
}
	