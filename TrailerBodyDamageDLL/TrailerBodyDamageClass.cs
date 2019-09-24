/* Title:           Trailer Body Damage Class
 * Date:            9-25-18
 * Author:          Terrance Holmes
 * 
 * Description:     This class is for  documenting trailer body damage */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TrailerBodyDamageDLL
{
    public class TrailerBodyDamageClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        TrailerBodyDamageDataSet aTrailerBodyDamageDataSet;
        TrailerBodyDamageDataSetTableAdapters.trailerbodydamageTableAdapter aTrailerBodyDamageTableAdapter;

        InsertTrailerBodyDamageEntryTableAdapters.QueriesTableAdapter aInsertTrailerBodyDamageTableAdapter;

        UpdateTrailerBodyDamageEntryTableAdapters.QueriesTableAdapter aUpdateTrailerBodyDamageTableAdapter;

        FindOpenTrailerBodyDamageByTrailerIDDataSet aFindOpenTrailerBodyDamageByTrailerIDDataSet;
        FindOpenTrailerBodyDamageByTrailerIDDataSetTableAdapters.FindOpenTrailerBodyDamageByTrailerIDTableAdapter aFindOpenTrailerBodyDamageByTrailerIDTableAdapter;

        FindTrailerBodyDamageByTrailerIDDataSet aFindTrailerBodyDamageByTrailerIDDataSet;
        FindTrailerBodyDamageByTrailerIDDataSetTableAdapters.FindTrailerBodyDamageByTrailerIDTableAdapter aFindTrailerBodyDamageByTrailerIDTableAdapter;

        public FindTrailerBodyDamageByTrailerIDDataSet FindTrailerBodyDamageByTrailerID(int intTrailerID)
        {
            try
            {
                aFindTrailerBodyDamageByTrailerIDDataSet = new FindTrailerBodyDamageByTrailerIDDataSet();
                aFindTrailerBodyDamageByTrailerIDTableAdapter = new FindTrailerBodyDamageByTrailerIDDataSetTableAdapters.FindTrailerBodyDamageByTrailerIDTableAdapter();
                aFindTrailerBodyDamageByTrailerIDTableAdapter.Fill(aFindTrailerBodyDamageByTrailerIDDataSet.FindTrailerBodyDamageByTrailerID, intTrailerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Body Damage Class // Find Trailer Body Damage by Trailer ID " + Ex.Message);
            }

            return aFindTrailerBodyDamageByTrailerIDDataSet;
        }
        public FindOpenTrailerBodyDamageByTrailerIDDataSet FindOpenTrailerBodyDamageByTrailerID(int intTrailerID)
        {
            try
            {
                aFindOpenTrailerBodyDamageByTrailerIDDataSet = new FindOpenTrailerBodyDamageByTrailerIDDataSet();
                aFindOpenTrailerBodyDamageByTrailerIDTableAdapter = new FindOpenTrailerBodyDamageByTrailerIDDataSetTableAdapters.FindOpenTrailerBodyDamageByTrailerIDTableAdapter();
                aFindOpenTrailerBodyDamageByTrailerIDTableAdapter.Fill(aFindOpenTrailerBodyDamageByTrailerIDDataSet.FindOpenTrailerBodyDamageByTrailerID, intTrailerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Find Open Trailer Body Damage By Trailer ID " + Ex.Message);
            }

            return aFindOpenTrailerBodyDamageByTrailerIDDataSet;
        }
        public bool UpdateTrailerBodyDamage(int intTransactionID, DateTime datDateRepaired, bool blnDamagedFixed)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateTrailerBodyDamageTableAdapter = new UpdateTrailerBodyDamageEntryTableAdapters.QueriesTableAdapter();
                aUpdateTrailerBodyDamageTableAdapter.UpdateTrailerBodyDamage(intTransactionID, datDateRepaired, blnDamagedFixed);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Body Damage Class // Update Trailer Body Damage " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertTrailerBodyDamage(int intTrailerID, string strDamageReported)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTrailerBodyDamageTableAdapter = new InsertTrailerBodyDamageEntryTableAdapters.QueriesTableAdapter();
                aInsertTrailerBodyDamageTableAdapter.InsertTrailerBodyDamage(intTrailerID, DateTime.Now, DateTime.Now, strDamageReported, false);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Body Damage Class // Insert Trailer Body Damage " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TrailerBodyDamageDataSet GetTrailerBodyDamageInfo()
        {
            try
            {
                aTrailerBodyDamageDataSet = new TrailerBodyDamageDataSet();
                aTrailerBodyDamageTableAdapter = new TrailerBodyDamageDataSetTableAdapters.trailerbodydamageTableAdapter();
                aTrailerBodyDamageTableAdapter.Fill(aTrailerBodyDamageDataSet.trailerbodydamage);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Body Damage Class // Get Trailer Body Damage Info " + Ex.Message);
            }

            return aTrailerBodyDamageDataSet;
        }
        public void UpdateTrailerBodyDamageDB(TrailerBodyDamageDataSet aTrailerBodyDamageDataSet)
        {
            try
            {
                aTrailerBodyDamageTableAdapter = new TrailerBodyDamageDataSetTableAdapters.trailerbodydamageTableAdapter();
                aTrailerBodyDamageTableAdapter.Update(aTrailerBodyDamageDataSet.trailerbodydamage);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailer Body Damage Class // Update Trailer Body Damage DB " + Ex.Message);
            }
        }
    }
}
