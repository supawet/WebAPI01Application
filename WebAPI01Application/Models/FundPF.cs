using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI01Application.Models
{
    public class FundPF
    {
        //public long Id { get; set; }
        public string FUND_KIND { get; set; }
        public string FUND_TYPE { get; set; }
        public string PORT_CODE { get; set; }
        public string AMC_CODE { get; set; }
        public string AMC_NAME { get; set; }
        public string FUND_NAME_TH { get; set; }
        public string FUND_NAME_EN { get; set; }
        public string FUND_CODE { get; set; }
        public double? AUM { get; set; }
        public double? NAV { get; set; }
        public double? DIVIDEND { get; set; }
        public string DIVIDEND_DATE { get; set; }
        public double? PRICE { get; set; }
        public double? REDEMPTION_PRICE { get; set; }
        public double? MINIMUM_FIRST_ORDER { get; set; }
        public double? MINIMUM_NEXT_ORDER { get; set; }
        public double? MANAGEMENT_FEE { get; set; }
        public string INCEPTION_DATE { get; set; }
        public double? RISK { get; set; }
        public double? RETURN_1D { get; set; }
        public double? RETURN_1M { get; set; }
        public double? RETURN_3M { get; set; }
        public double? RETURN_6M { get; set; }
        public double? RETURN_YTD { get; set; }
        public double? RETURN_1Y { get; set; }
        public double? RETURN_3Y { get; set; }
        public double? RETURN_5Y { get; set; }
        public double? SD_1D { get; set; }
        public double? SD_1M { get; set; }
        public double? SD_3M { get; set; }
        public double? SD_6M { get; set; }
        public double? SD_YTD { get; set; }
        public double? SD_1Y { get; set; }
        public double? SD_3Y { get; set; }
        public double? SD_5Y { get; set; }
        public double? BENCHMARK_YTD { get; set; }
        public double? BENCHMARK_3M { get; set; }
        public double? BENCHMARK_6M { get; set; }
        public double? BENCHMARK_1Y { get; set; }
        public double? BENCHMARK_3Y { get; set; }
        public double? BENCHMARK_5Y { get; set; }
        public string BENCHMARK_NAME { get; set; }
        public string RETURN_1D_DATE { get; set; }
        public string RETURN_1M_DATE { get; set; }
        public string RETURN_3M_DATE { get; set; }
        public string RETURN_6M_DATE { get; set; }
        public string RETURN_YTD_DATE { get; set; }
        public string RETURN_1Y_DATE { get; set; }
        public string RETURN_3Y_DATE { get; set; }
        public string RETURN_5Y_DATE { get; set; }
        public double? RETURN_INC { get; set; }
        public string RETURN_INC_DATE { get; set; }
        public double? SD_INC { get; set; }
        public double? BENCHMARK_SD_1D { get; set; }
        public double? BENCHMARK_SD_1M { get; set; }
        public double? BENCHMARK_SD_3M { get; set; }
        public double? BENCHMARK_SD_6M { get; set; }
        public double? BENCHMARK_SD_YTD { get; set; }
        public double? BENCHMARK_SD_1Y { get; set; }
        public double? BENCHMARK_SD_3Y { get; set; }
        public double? BENCHMARK_SD_5Y { get; set; }
        public double? BENCHMARK_SD_INC { get; set; }
        public double? BENCHMARK_INC { get; set; }
        public string BENCHMARK2_NAME { get; set; }
        public double? BENCHMARK2_YTD { get; set; }
        public double? BENCHMARK2_3M { get; set; }
        public double? BENCHMARK2_6M { get; set; }
        public double? BENCHMARK2_1Y { get; set; }
        public double? BENCHMARK2_3Y { get; set; }
        public double? BENCHMARK2_5Y { get; set; }
        public double? BENCHMARK2_INC { get; set; }
        public double? BENCHMARK_SD2_1D { get; set; }
        public double? BENCHMARK_SD2_1M { get; set; }
        public double? BENCHMARK_SD2_3M { get; set; }
        public double? BENCHMARK_SD2_6M { get; set; }
        public double? BENCHMARK_SD2_YTD { get; set; }
        public double? BENCHMARK_SD2_1Y { get; set; }
        public double? BENCHMARK_SD2_3Y { get; set; }
        public double? BENCHMARK_SD2_5Y { get; set; }
        public double? BENCHMARK_SD2_INC { get; set; }
        public string NAV_DATE { get; set; }
    }
}