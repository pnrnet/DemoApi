namespace Common.DbHelper
{
    /// <summary>
    /// Purpose of this class is connect with database and return result in dynamic object.
    /// </summary>
    public class DatabaseOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOptions"/> class.
        /// Database Options.
        /// </summary>
        /// <param name="dataConnection">Db Connection.</param>
        public DatabaseOptions(string dataConnection)
        {
            this.DBConnection = dataConnection;
        }

        /// <summary>
        /// Gets the DBConnection connection.
        /// </summary>
        /// <value>The DBConnection connection.</value>
        public string DBConnection { get; private set; }
    }
}
