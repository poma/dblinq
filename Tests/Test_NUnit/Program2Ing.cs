#region HEADER
using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Test_NUnit_Ingres;
#endregion

namespace Test_NUnit_Ingres
{
#region HEADER
    /// <summary>
    /// when a problem crops up in NUnit, you can convert the project from DLL into EXE, 
    /// and debug into the offending method.
    /// </summary>
#endregion
    class Program2
    {
        static void Main()
        {
            /*==========================================================================*/
            /* All failing Tests are recorded here. They will be removed, once they run */
            /*==========================================================================*/

            /*==================================================================*/
            /* The following failing tests are investigated, but not solved yet */
            /*==================================================================*/
            // generates this SQL
            // SELECT $.categoryid, $.discontinued, $.productid, $.productname, 
            // $.quantityperunit, $.reorderlevel, $.supplierid, $.unitprice, $.unitsinstock, $.unitsonorder
            // FROM linquser.products $ WHERE $.supplierid = 1 AND $.unitsinstock > 2 ORDER BY $.productid
            // which failes as a single $ sign is not allowed for a table alias
            //new DynamicLinqTest().DL1_Products();

            // SELECT COUNT(*) FROM linquser.products p$ ORDER BY p$.productid
            // productid not found
            // I don't get this test. Why should I do a count(*) and then order it by a field
            // that is actually not in the resultset?
            //new ReadTest().C4_CountWithOrderBy();

            // The parameters are added to the query in reverse order. Ingres can't handle this,
            // as all params are called "?"
            //new ReadTest_Complex().D2_SelectPensByLocalPropertyAndConstant();

            // Yields this SQL:
            // SELECT ((p$.productname||?)||VARCHAR(p$.supplierid)) FROM linquser.products p$
            // A parameter before the FROM crashes the Ingres driver. Known problem.
            // Both tests fail due to this
            //new ReadTest_Operands().H1_SelectConcat();
            //new Linq_101_Samples.String_Date_functions().LinqToSqlString01();

            // Ingres does not support booleans. there needs to be some workaround...
            // Both these tests fail due to this
            //new Linq_101_Samples.AdvancedTest().LinqToSqlAdvanced06();
            //new Linq_101_Samples.Count_Sum_Min_Max_Avg().LinqToSqlCount02();

            // NullRef exception in FromClausebuilder
            //new Linq_101_Samples.Join().LinqToSqlJoin10();

            // OFFSET clause is not supported in Ingres
            // Both tests fail due to this.
            //new Linq_101_Samples.Top_Bottom().LinqToSqlTop02();
            //new Linq_101_Samples.Top_Bottom().LinqToSqlTop03_Ex_Andrus();
        }
    }
}
