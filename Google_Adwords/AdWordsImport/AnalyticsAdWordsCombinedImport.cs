

// Author: Aram Tovmasyan

using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.Util.Reports;
using Google.Api.Ads.AdWords.v201309;

using System;
using System.Collections.Generic;
using System.IO;

namespace AdWordsImport.Examples.CSharp.v201309 {
  /// <summary>
  /// This code example gets and downloads a criteria Ad Hoc report from an XML
  /// report definition.
  /// </summary>
    public class AnalyticsAdWordsCombinedImport : ExampleBase
    {
    /// <summary>
    /// Main method, to run this code example as a standalone application.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args) {
        AnalyticsAdWordsCombinedImport codeExample = new AnalyticsAdWordsCombinedImport();
      Console.WriteLine(codeExample.Description);
      try {
          
          string repName = "AD_PERFORMANCE_REPORT";

            
             string[] fields = new string[] { 
               "AccountDescriptiveName"
               ,"Headline"
               ,"AdGroupName"
               ,"Id" //Ad id
               ,"Status"
               ,"AdType"
               ,"AverageCpc"
               ,"AverageCpm"
               ,"AveragePosition"
               ,"CampaignName"
               ,"Clicks"
               ,"Conversions"
               ,"ConversionRate"
               ,"Cost"
               ,"CostPerConversion"
               ,"Ctr"
               ,"Date"
               ,"Description1"
               ,"Description2"
               ,"CreativeDestinationUrl"
               ,"DisplayUrl"
               ,"Impressions"
               ,"ViewThroughConversions"
               ,"KeywordId"
         };
/*
             string[] fields = new string[] { 
               "AccountCurrencyCode"
               ,"AccountDescriptiveName"
               ,"AccountTimeZoneId"
               ,"AdGroupAdDisapprovalReasons"
               ,"AdGroupId"
               ,"AdGroupName"
               ,"AdGroupStatus"
               ,"AdType"
               ,"AverageCpc"
               ,"AverageCpm"
               ,"AveragePosition"
               ,"CampaignId"
               ,"CampaignName"
               ,"CampaignStatus"
               ,"Clicks"
               ,"ClickSignificance"
               ,"ConversionManyPerClickSignificance"
               ,"ConversionRate"
               ,"ConversionRateManyPerClick"
               ,"ConversionRateManyPerClickSignificance"
               ,"ConversionRateSignificance"
               ,"Conversions"
               ,"ConversionSignificance"
               ,"ConversionsManyPerClick"
               ,"ConversionValue"
               ,"Cost"
               ,"CostPerConversion"
               ,"CostPerConversionManyPerClick"
               ,"CostPerConversionManyPerClickSignificance"
               ,"CostPerConversionSignificance"
               ,"CostSignificance"
               ,"CpcSignificance"
               ,"CpmSignificance"
               ,"CreativeApprovalStatus"
               ,"CreativeDestinationUrl"
               ,"Ctr"
               ,"CtrSignificance"
               ,"CustomerDescriptiveName"
               ,"Description1"
               ,"Description2"
               ,"DevicePreference"
               ,"DisplayUrl"
               ,"ExternalCustomerId"
               ,"Headline"
               ,"Id"
               ,"ImageAdUrl"
               ,"ImageCreativeName"
               ,"Impressions"
               ,"ImpressionSignificance"
               ,"IsNegative"
               ,"KeywordId"
               ,"PositionSignificance"
               ,"PrimaryCompanyName"
               ,"PrimaryUserLogin"
               ,"PromotionLine"
               ,"SharedSetName"
               ,"Status"
               ,"TotalConvValue"
               ,"Url"
               ,"ValuePerConv"
               ,"ValuePerConversion"
               ,"ValuePerConversionManyPerClick"
               ,"ValuePerConvManyPerClick"
               ,"ViewThroughConversions"
               ,"ViewThroughConversionsSignificance"
         
              //,"Date"
           
             };
    */      
           
          string user = "302-410-1700";//Questrade Main
          codeExample.Run(user, repName, fields);
          user = "371-748-3622";//Questrade Main Search
          codeExample.Run(user, repName, fields);
          
          repName = "CRITERIA_PERFORMANCE_REPORT"; //https://developers.google.com/adwords/api/docs/appendix/reports#criteria

          fields = new string[] { 
               "AccountCurrencyCode"
             ,"AccountDescriptiveName"
             ,"AccountTimeZoneId"
             ,"AdGroupId"
             ,"AdGroupName"
             ,"AdGroupStatus"
             ,"ApprovalStatus"
             ,"BidModifier"
             ,"CampaignId"
             ,"CampaignName"
             ,"CampaignStatus"
             ,"CpcBidSource"
             ,"Criteria"
             ,"CriteriaDestinationUrl"
             ,"CriteriaType"
             ,"CustomerDescriptiveName"
             ,"Date"
             ,"DisplayName"
             ,"ExternalCustomerId"
             ,"FirstPageCpc"
             ,"Id"
             ,"IsNegative"
             ,"MaxCpc"
             ,"MaxCpm"
             ,"Parameter"
             ,"PercentCpa"
             ,"PrimaryCompanyName"
             ,"PrimaryUserLogin"
             ,"QualityScore"
             ,"Status"
           };
         /*
           fields = new string[] { 
                 "AccountCurrencyCode"
                 ,"AccountDescriptiveName"
                 ,"AccountTimeZoneId"
                 ,"AdGroupId"
                 ,"AdGroupName"
                 ,"AdGroupStatus"
                 ,"AdNetworkType1"
                 ,"AdNetworkType2"
                 //,"AdvertiserExperimentSegmentationBin"
                 ,"ApprovalStatus"
                 ,"AverageCpc"
                 ,"AverageCpm"
                 ,"AveragePosition"
                 ,"BidModifier"
                 ,"CampaignId"
                 ,"CampaignName"
                 ,"CampaignStatus"
                 ,"Clicks"
                 ,"ClickSignificance"
                 ,"ClickType"
                 ,"ConversionCategoryName"
                 ,"ConversionManyPerClickSignificance"
                 ,"ConversionRate"
                 ,"ConversionRateManyPerClick"
                 ,"ConversionRateManyPerClickSignificance"
                 ,"ConversionRateSignificance"
                 ,"Conversions"
                 ,"ConversionSignificance"
                 ,"ConversionsManyPerClick"
                 ,"ConversionTypeName"
                 ,"ConversionValue"
                 ,"Cost"
                 ,"CostPerConversion"
                 ,"CostPerConversionManyPerClick"
                 ,"CostPerConversionManyPerClickSignificance"
                 ,"CostPerConversionSignificance"
                 ,"CostSignificance"
                 ,"CpcBidSource"
                 ,"CpcSignificance"
                 ,"CpmSignificance"
                 ,"Criteria"
                 ,"CriteriaDestinationUrl"
                 ,"CriteriaType"
                 ,"Ctr"
                 ,"CtrSignificance"
                 ,"CustomerDescriptiveName"
                 ,"Date"
                 ,"DayOfWeek"
                 ,"Device"
                 ,"DisplayName"
                 ,"ExternalCustomerId"
                 ,"FirstPageCpc"
                 ,"Id"
                 ,"Impressions"
                 ,"ImpressionSignificance"
                 ,"IsNegative"
                 ,"MaxCpc"
                 ,"MaxCpm"
                 ,"Month"
                 ,"MonthOfYear"
                 ,"Parameter"
                 ,"PercentCpa"
                 ,"PositionSignificance"
                 ,"PrimaryCompanyName"
                 ,"PrimaryUserLogin"
                 ,"QualityScore"
                 ,"Quarter"
                 ,"Slot"
                 ,"Status"
                 ,"TopOfPageCpc"
                 ,"TotalConvValue"
                 ,"ValuePerConv"
                 ,"ValuePerConversion"
                 ,"ValuePerConversionManyPerClick"
                 ,"ValuePerConvManyPerClick"
                 ,"ViewThroughConversions"
                 ,"ViewThroughConversionsSignificance"
                 ,"Week"
                 ,"Year"
            };
           */

          user = "302-410-1700";//Questrade Main
          codeExample.Run(user, repName, fields);
          user = "371-748-3622";//Questrade Main Search
          codeExample.Run(user, repName, fields);



      } catch (Exception ex) {
        Console.WriteLine("An exception occurred while running this code example. {0}",
            ExampleUtilities.FormatException(ex));
      }
    }

    /// <summary>
    /// Returns a description about the code example.
    /// </summary>
    public override string Description {
      get {
        return "This code example gets and downloads a criteria Ad Hoc report from an XML report " +
            "definition.";
      }
    }

    /// <summary>
    /// Runs the code example.
    /// </summary>
    /// <param name="user">The AdWords user.</param>
    /// <param name="fileName">The file to which the report is downloaded.
    /// </param>
    public void Run(string p_user, string p_repName, string[] p_fields)
    {
      
      AdWordsUser user = new AdWordsUser();
      ((AdWordsAppConfig)user.Config).ClientCustomerId = p_user;

      ReportDefinition definition = new ReportDefinition();

      definition.reportName = "Nov2013_ " + p_repName;
      definition.reportType = (ReportDefinitionReportType)Enum.Parse(typeof(ReportDefinitionReportType), p_repName);
      definition.downloadFormat = DownloadFormat.GZIPPED_CSV;
      definition.dateRangeType = ReportDefinitionDateRangeType.CUSTOM_DATE;
      
      
    

      // Create selector.
      Selector selector = new Selector();

      selector.dateRange = new Google.Api.Ads.AdWords.v201309.DateRange();
      string start = string.Format("{0:yyyy-MM-dd}", "2013-11-01");
      start = start.Replace("-", "");
      selector.dateRange.min = start;

      string end = string.Format("{0:yyyy-MM-dd}", "2013-11-30");
      end = end.Replace("-", "");
      selector.dateRange.max = end;  



      selector.fields = p_fields;

/*
      Predicate predicate = new Predicate();
      predicate.field = "Status";
      predicate.@operator = PredicateOperator.IN;
      predicate.values = new string[] {"ACTIVE", "PAUSED"};
      selector.predicates = new Predicate[] {predicate};
        */

      definition.selector = selector;


      //definition.includeZeroImpressions = true;

      //string filePath = ExampleUtilities.GetHomeDir() + Path.DirectorySeparatorChar + p_repName +"_"+p_user+ ".GZ";
      string filePath = "C:\\TEMP\\GOOGLE" + Path.DirectorySeparatorChar + p_repName + "_" + p_user + ".GZ";  

      try {
        // If you know that your report is small enough to fit in memory, then
        // you can instead use
        // ReportUtilities utilities = new ReportUtilities(user);
        // utilities.ReportVersion = "v201309";
        // ClientReport report = utilities.GetClientReport(definition);
        //
        // // Get the text report directly if you requested a text format
        // // (e.g. xml)
        // string reportText = report.Text;
        //
        // // Get the binary report if you requested a binary format
        // // (e.g. gzip)
        // byte[] reportBytes = report.Contents;
        //
        // // Deflate a zipped binary report for further processing.
        // string deflatedReportText = Encoding.UTF8.GetString(
        //     MediaUtilities.DeflateGZipData(report.Contents));
        ReportUtilities utilities = new ReportUtilities(user);
        utilities.ReportVersion = "v201309";

        utilities.DownloadClientReport(definition, false, filePath);
        Console.WriteLine("Report was downloaded to '{0}'.", filePath);
      } catch (Exception ex) {
        throw new System.ApplicationException("Failed to download report.", ex);
      }
    }
  }
}
