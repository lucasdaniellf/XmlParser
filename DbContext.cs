using Npgsql;

namespace XmlParser
{
    internal class DbContext
    {
        internal DbContext()
        {
            ConnString = "";
        }

        private string ConnString { get; set; } = null!;
        internal NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnString);
        }
    }
}
