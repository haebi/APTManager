using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APTManager
{
    class BillModel
    {
        private string home;            // 세대
        private string name;            // 세대주
        private string yyyymm;          // 년월
        private string premonth;        // 전월지침
        private string thismonth;       // 당월지침
        private string useamount;       // 사용량
        private string usecost;         // 사용금액
        private string managecost;      // 관리비
        private string totalthismonth;  // 합계
        private string uncharged;       // 미납금
        private string totalcost;       // 청구금
        private string remark;          // 비고

        public string Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Yyyymm
        {
            get
            {
                return yyyymm;
            }

            set
            {
                yyyymm = value;
            }
        }

        public string Premonth
        {
            get
            {
                return premonth;
            }

            set
            {
                premonth = value;
            }
        }

        public string Thismonth
        {
            get
            {
                return thismonth;
            }

            set
            {
                thismonth = value;
            }
        }

        public string Usecost
        {
            get
            {
                return usecost;
            }

            set
            {
                usecost = value;
            }
        }

        public string Managecost
        {
            get
            {
                return managecost;
            }

            set
            {
                managecost = value;
            }
        }

        public string Totalthismonth
        {
            get
            {
                return totalthismonth;
            }

            set
            {
                totalthismonth = value;
            }
        }

        public string Uncharged
        {
            get
            {
                return uncharged;
            }

            set
            {
                uncharged = value;
            }
        }

        public string Totalcost
        {
            get
            {
                return totalcost;
            }

            set
            {
                totalcost = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public string Useamount
        {
            get
            {
                return useamount;
            }

            set
            {
                useamount = value;
            }
        }
    }
}
