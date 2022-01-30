using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using VK.ITMO.EXAM.Models;

namespace VK.ITMO.EXAM.Data
{
   internal class DBAccess
    {
        private static string connectionString = "null";

        public static void DBSetConnectionParameters(string name, string pass, string path)
        {
            connectionString = $"Password={pass};Persist Security Info=True;User ID={name};Initial Catalog=ExamDB;Data Source={path}";
        }

        public static void DBSetConnectionParameters(string path) 
        {
            connectionString = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ExamDB;Data Source={path}";
            
        }

        public List<ReportModel> GetReports()
        {
            List<ReportModel> reports = new List<ReportModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM[ExamDB].[Istochnik].[TableSource]", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                        
                        while (reader.Read())
                        {
                            ReportModel rep = new ReportModel();
                            rep.LineID = int.Parse( reader[0].ToString() );
                            rep.ParameterID = int.Parse(reader[1].ToString());
                            rep.PeriodID = reader[2].ToString();
                            rep.PeriodStart = DateTime.Parse(reader[3].ToString());
                            rep.PeriodEnd = DateTime.Parse(reader[4].ToString());
                            rep.TerID = reader[5].ToString();
                            rep.Value = Decimal.Parse(reader[6].ToString());
                            reports.Add(rep);
                        }
                    }
                }
            }
            return reports;
        }

        public bool UpdateRecord(ReportModel r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE [Istochnik].[TableSource] SET nPokazatelId=" + r.ParameterID.ToString()
                                                        +", vPeriodType='" + r.PeriodID
                                                        +"', dtStartDate='" + r.PeriodStart.ToString("yyyy-MM-dd")
                                                        +"', dtEndDate='" + r.PeriodEnd.ToString("yyyy-MM-dd")
                                                        +"', vTerritoryId='" + r.TerID
                                                        +"', nValue=" + r.Value.ToString("G", CultureInfo.CreateSpecificCulture("en-US"))
                                                        + " WHERE LineId=" + r.LineID.ToString(), conn))
                {
                    if (cmd.ExecuteNonQuery() != 0)
                        return true;
                }
            }
            return false;
        }

        public bool DeleteRecord(int idx)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM Istochnik.TableSource WHERE LineID={idx.ToString()}", conn))
                {
                    if (cmd.ExecuteNonQuery() != 0)
                        return true;
                }
            }
            return false;
        }

        public bool InsertRecord(ReportModel r)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Istochnik].[TableSource] VALUES (" + r.ParameterID.ToString()
                    + ",'" + r.PeriodID
                    + "','" + r.PeriodStart.ToString("yyyy-MM-dd")
                    + "','" + r.PeriodEnd.ToString("yyyy-MM-dd")
                    + "','" + r.TerID
                    + "'," + r.Value.ToString("G", CultureInfo.CreateSpecificCulture("en-US")) + ")"
                    , conn ))
                {
                    if (cmd.ExecuteNonQuery() != 0)
                        return true;
                }
            }
            return false;
        }
    }
}
