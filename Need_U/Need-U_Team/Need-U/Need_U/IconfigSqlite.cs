﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Need_U
{
    public interface IconfigSqlite
    {

        SQLiteConnection GetConnection();

    }
}
