using System;
using System.Collections.Generic;
using System.Text;

/**
 * This Exception will be thrown if the DB give an error
 * 
 */

namespace beans.exceptions.db
{
    public class DbException : Exception    
    {
        //call super class constructor
        public DbException(String message)
            : base(message)
        {}
    }
}
