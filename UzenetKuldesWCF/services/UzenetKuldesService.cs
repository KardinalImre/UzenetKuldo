using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UzenetKuldesWCF.models;

namespace UzenetKuldesWCF.services
{
    public class UzenetKuldesService
    {
        private readonly string connectionString = "SERVER = localhost;" +
                          "DATABASE= uzenetkuldo;" +
                          "UID = root;" +
                          "PASSWORD =;";


        public string Create(Tablazat tablazat)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO uzenet (Szoveg, KuldesiIdo, UzenetTipus, Telefon, Email) VALUES (@Szoveg, @KuldesiIdo, @UzenetTipus, @Telefon, @Email)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Szoveg", (tablazat as Uzenet).Szoveg);
                    cmd.Parameters.AddWithValue("@KuldesiIdo", (tablazat as Uzenet).KuldesiIdo);
                    cmd.Parameters.AddWithValue("@UzenetTipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@Telefon", (tablazat as Uzenet).Telefon);
                    cmd.Parameters.AddWithValue("@Email", (tablazat as Uzenet).Email);

                    int sorokszama = cmd.ExecuteNonQuery();

                    return sorokszama > 0 ? "Sikeres beszúrás" : "Sikertelen beszúrás";
                }
            }
        }

        public string Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM uzenet WHERE Id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    int sorokszama = cmd.ExecuteNonQuery();

                    return sorokszama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
                }
            }
        }

        public List<Tablazat> Read()
        {
            List<Tablazat> tablazatok = new List<Tablazat>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM uzenet";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Uzenet uzenet = new Uzenet();
                        uzenet.Id = reader.GetInt32("Id");
                        uzenet.Szoveg = reader.GetString("Szoveg");
                        uzenet.KuldesiIdo = reader.GetDateTime("KuldesiIdo");
                        uzenet.UzenetTipus = reader.GetString("UzenetTipus");
                        uzenet.Telefon = reader.GetString("Telefon");
                        uzenet.Email = reader.GetString("Email");
                        tablazatok.Add(uzenet);
                    }
                }
            }

            return tablazatok;
        }

        public string Update(Tablazat tablazat)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE uzenet SET Szoveg = @Szoveg, KuldesiIdo = @KuldesiIdo, UzenetTipus = @UzenetTipus, Telefon = @Telefon, Email = @Email WHERE Id = @Id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", (tablazat as Uzenet).Id);
                    cmd.Parameters.AddWithValue("@Szoveg", (tablazat as Uzenet).Szoveg);
                    cmd.Parameters.AddWithValue("@KuldesiIdo", (tablazat as Uzenet).KuldesiIdo);
                    cmd.Parameters.AddWithValue("@UzenetTipus", (tablazat as Uzenet).UzenetTipus);
                    cmd.Parameters.AddWithValue("@Telefon", (tablazat as Uzenet).Telefon);
                    cmd.Parameters.AddWithValue("@Email", (tablazat as Uzenet).Email);

                    int sorokszama = cmd.ExecuteNonQuery();

                    return sorokszama > 0 ? "Sikeres frissítés" : "Sikertelen frissítés";
                }
            }
        }
    }
}