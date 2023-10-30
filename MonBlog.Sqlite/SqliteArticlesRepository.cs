using Microsoft.Data.Sqlite;
using MonBlog.Database.Abstractions;

namespace MonBlog.Sqlite
{
    public class SqliteArticlesRepository : IArticlesRepository
    {
        private SqliteConnection _connection = new (":memory:");

        /// <inheritdoc />
        public IEnumerable<Article> FetchAllArticles(string tag)
        {
            try
            {
                _connection.Open();
                using var command = _connection.CreateCommand();
                command.CommandText = "SELECT title FROM articles WHERE tag = @tag";

                var tagParameter = command.CreateParameter();
                tagParameter.ParameterName = "tag";
                tagParameter.SqliteType = SqliteType.Text;
                tagParameter.Size = 32;
                tagParameter.Value = tag;
                command.Parameters.Add(tagParameter);

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