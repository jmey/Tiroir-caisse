using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace TiroirCaisse.ExternAccess
{
    public class SQLiteAccess
    {

        #region Attributs

        private static SQLiteAccess _Instance;
        private bool Connected { get; set; }
        private SQLiteConnection Connection { get; set; }
        private SQLiteConnection ConnectionBackup { get; set; }
        public static SQLiteAccess Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new SQLiteAccess();
                }
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        #endregion


        #region Constructeurs

        private SQLiteAccess()
        {
            Connection = new SQLiteConnection("Data Source=" + @Properties.Settings.Default.PathDB + "; Version=3; Legacy Format=True;");
            ConnectionBackup = new SQLiteConnection("Data Source=" + @Properties.Settings.Default.PathBackup + "; Version=3; Legacy Format=True;");
            Connected = false;
        }

        #endregion


        #region Méthodes

        #region Privées

        private int OpenConnection()
        {
            try
            {
                Connection.Open();
                ConnectionBackup.Open();
                Connected = true;
            }
            catch
            {
                return 1;
            }
            return 0;
        }
        private int CloseConnection()
        {
            try
            {
                Connection.Close();
                ConnectionBackup.Close();
                Connected = false;
            }
            catch
            {
                return 2;
            }
            return 0;
        }

        #endregion

        #region Publics

        public SQLiteDataReader ExecuteCommandWReturn(string _command)
        {
            if (!Connected)
                OpenConnection();

            SQLiteCommand oCommand = new SQLiteCommand(_command, Connection);
            SQLiteDataReader oReader;
            try
            {
                oReader = oCommand.ExecuteReader();
            }
            catch
            {
                oReader = null;
            }
            return oReader;
        }

        public int ExecuteComandWOReturn(string _command)
        {
            SQLiteTransaction transaction = null;
            if (!Connected)
                OpenConnection();
            SQLiteCommand oCommand = new SQLiteCommand(_command, Connection);
            SQLiteCommand oCommandBackup = new SQLiteCommand(_command, ConnectionBackup);
            int res;

            if (Properties.Settings.Default.TestMode)
            {
                transaction = Connection.BeginTransaction();
                oCommand.Transaction = transaction;
            }

            try
            {
                res = oCommand.ExecuteNonQuery();
                try
                {
                    oCommandBackup.ExecuteNonQuery();
                }
                catch { }
            }
            catch
            {
                res = -1;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            return res;
        }

        #endregion

        #endregion
    }
}
