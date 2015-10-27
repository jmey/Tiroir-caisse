using Microsoft.VisualStudio.TestTools.UnitTesting;
using TiroirCaisse.ExternAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TiroirCaisse.ExternAccess.Tests
{
    [TestClass()]
    public class SQLiteAccessTests
    {
        [TestMethod()]
        public void ExecuteCommandWReturnTest()
        {
            SQLiteAccess sqlLiteAccess = SQLiteAccess.Instance;
            SQLiteDataReader reader = sqlLiteAccess.ExecuteCommandWReturn("SELECT * FROM client;");
            Assert.AreEqual(1, reader.StepCount);
        }

        [TestMethod()]
        public void ExecuteComandWOReturnTest()
        {
            SQLiteAccess sqlLiteAccess = SQLiteAccess.Instance;
            int res = sqlLiteAccess.ExecuteComandWOReturn("INSERT INTO client(id, nom, prenom, date_arrivee, telephone_fixe, telephone_portable) VALUES(2, 'DORR', 'Alexis', 672278400, '0123456789', '0123456789');");
            Assert.AreEqual(res, 1);
        }
    }
}