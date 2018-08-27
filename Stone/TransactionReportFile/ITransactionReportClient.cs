using System;
using System.Net;
using StonePaymentGateway.Utility;

namespace StonePaymentGateway.TransactionReportFile {

    public interface ITransactionReportClient {

        HttpResponse DownloadReport(DateTime fileDate);

        HttpStatusCode DownloadReportToFile(DateTime fileDate, string fileName);
    }
}