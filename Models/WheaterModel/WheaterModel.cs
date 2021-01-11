using System;

namespace weather_forecast_bot
{
    public enum Lang
    {
        ru_RU = 0,
        ru_UA = 1,
        uk_UA = 2,
        be_BY = 3,
        kk_KZ = 4,
        tr_TR = 5,
        en_US = 6
    }

    public class WheaterModel
    {
        public int now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public Geo_Object geo_object { get; set; }
        public Yesterday yesterday { get; set; }
        public Fact fact { get; set; }
        public Forecast[] forecasts { get; set; }
    }

    public class Info
    {
        public bool n { get; set; }
        public int geoid { get; set; }
        public string url { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public Tzinfo tzinfo { get; set; }
        public int def_pressure_mm { get; set; }
        public int def_pressure_pa { get; set; }
        public string slug { get; set; }
        public int zoom { get; set; }
        public bool nr { get; set; }
        public bool ns { get; set; }
        public bool nsr { get; set; }
        public bool p { get; set; }
        public bool f { get; set; }
        public bool _h { get; set; }
    }

    public class Tzinfo
    {
        public string name { get; set; }
        public string abbr { get; set; }
        public bool dst { get; set; }
        public int offset { get; set; }
    }

    public class Geo_Object
    {
        public District district { get; set; }
        public Locality locality { get; set; }
        public Province province { get; set; }
        public Country country { get; set; }
    }

    public class District
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Locality
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Province
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Yesterday
    {
        public int temp { get; set; }
    }

    public class Fact
    {
        public int obs_time { get; set; }
        public int uptime { get; set; }
        public int temp { get; set; }
        public int feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public int prec_prob { get; set; }
        public float prec_strength { get; set; }
        public bool is_thunder { get; set; }
        public float wind_speed { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public string season { get; set; }
        public string source { get; set; }
        public Accum_Prec accum_prec { get; set; }
        public float soil_moisture { get; set; }
        public int soil_temp { get; set; }
        public int uv_index { get; set; }
        public float wind_gust { get; set; }
    }

    public class Accum_Prec
    {
        public float _1 { get; set; }
        public float _3 { get; set; }
        public float _7 { get; set; }
    }

    public class Forecast
    {
        public string date { get; set; }
        public int date_ts { get; set; }
        public int week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string rise_begin { get; set; }
        public string set_end { get; set; }
        public int moon_code { get; set; }
        public string moon_text { get; set; }
        public Parts parts { get; set; }
        public Hour[] hours { get; set; }
        public Biomet biomet { get; set; }
    }

    public class Parts
    {
        public Night_Short night_short { get; set; }
        public Day_Short day_short { get; set; }
        public Night night { get; set; }
        public Day day { get; set; }
        public Evening evening { get; set; }
        public Morning morning { get; set; }
    }

    public class Night_Short
    {
        public string _source { get; set; }
        public int temp { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Day_Short
    {
        public string _source { get; set; }
        public int temp { get; set; }
        public int temp_min { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Night
    {
        public string _source { get; set; }
        public int temp_min { get; set; }
        public int temp_avg { get; set; }
        public int temp_max { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Day
    {
        public string _source { get; set; }
        public int temp_min { get; set; }
        public int temp_avg { get; set; }
        public int temp_max { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Evening
    {
        public string _source { get; set; }
        public int temp_min { get; set; }
        public int temp_avg { get; set; }
        public int temp_max { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Morning
    {
        public string _source { get; set; }
        public int temp_min { get; set; }
        public int temp_avg { get; set; }
        public int temp_max { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_prob { get; set; }
        public int prec_period { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int uv_index { get; set; }
        public int feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Biomet
    {
        public int index { get; set; }
        public string condition { get; set; }
    }

    public class Hour
    {
        public string hour { get; set; }
        public int hour_ts { get; set; }
        public int temp { get; set; }
        public int feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public float cloudness { get; set; }
        public int prec_type { get; set; }
        public float prec_strength { get; set; }
        public bool is_thunder { get; set; }
        public string wind_dir { get; set; }
        public float wind_speed { get; set; }
        public float wind_gust { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int uv_index { get; set; }
        public int soil_temp { get; set; }
        public float soil_moisture { get; set; }
        public float prec_mm { get; set; }
        public int prec_period { get; set; }
        public int prec_prob { get; set; }
    }
}