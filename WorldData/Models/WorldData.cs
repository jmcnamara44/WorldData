using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    private int _cityId;
    private string _cityName;
    private string _cityCountryCode;
    private int _cityPopulation;

    public City (int id, string name, string countryCode, int population)
    {
      _cityId = id;
      _cityName = name;
      _cityCountryCode = countryCode;
      _cityPopulation = population;
    }
    public int GetCityId()
    {
      return _cityId;
    }
    public string GetCityName()
    {
      return _cityName;
    }
    public string GetCityCountryCode()
    {
      return _cityCountryCode;
    }
    public int GetCityPopulation()
    {
      return _cityPopulation;
    }
    public static List<City> GetAll()
        {
            List<City> allCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city WHERE Population < 1000;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string cityName = rdr.GetString(1);
              string cityCountryCode = rdr.GetString(2);
              int cityPopulation = rdr.GetInt32(4);
              City newCity = new City(cityId, cityName, cityCountryCode, cityPopulation);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;




    }

  }
  public class Country
  {

  }
}
