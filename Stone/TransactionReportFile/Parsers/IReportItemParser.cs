using StonePaymentGateway.TransactionReportFile.Report;

namespace StonePaymentGateway.TransactionReportFile.Parsers {

    internal interface IReportItemParser {

        IReportItem Parse(string[] elements);
    }
}
