using System.IO;
using StonePaymentGateway.TransactionReportFile.Report;

namespace StonePaymentGateway.TransactionReportFile {

    public interface ITransactionReportParser {

        TransactionReport ParseFile(string filename);

        TransactionReport ParseStream(Stream stream);

        TransactionReport ParseString(string reportContent);
    }
}