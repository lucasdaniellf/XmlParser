using Npgsql;

namespace XmlParser
{
    internal class DbContext
    {
        internal DbContext()
        {
            ConnString = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=NFe";
        }

        private string ConnString { get; set; } = null!;
        internal NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnString);
        }
    }
}
