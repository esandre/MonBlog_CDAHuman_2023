using Microsoft.Data.Sqlite;
using MonBlog.Database.Abstractions;

namespace MonBlog.Sqlite
{
    public class SqliteArticlesRepository : IArticlesRepository
    {
        private SqliteConnection _connection = new (":memory:");

        /// <inheritdoc />
        public IEnumerable<Article> FetchAllArticles()
        {
            try
            {
                _connection.Open();
                using var command = _connection.CreateCommand();
                command.CommandText = "SELECT title FROM articles";

                var reader = command.ExecuteReader();

                var articles = new List<Article>();

                while (reader.HasRows)
                {
                    var titre = reader.GetString(0);
                    articles.Add(new Article(titre));
                }

                return articles;
            } 
            finally
            {
                _connection.Close();
            }
        }
    }
}