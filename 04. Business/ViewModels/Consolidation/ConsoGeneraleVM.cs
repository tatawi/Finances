using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consolidation
{
    public class ConsoGeneraleVM
    {
        public string User { get; set; }
        public bool IsForperso { get; set; }
        public string Message { get; set; }

        public List<ConsolidationGeneraleVM> list_recaps { get; set; }
        public List<ConsolidationGeneraleVM> list_recapsMoyenne { get; set; }
    }
}
