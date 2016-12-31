using DAO;

namespace CDServiceWCF.Entity
{
    public class SearchCDs_Advanced_Input
    {
        public int Page;
        public bool Filter_isMixed;
        public Media_Music_CDs SearchCD;
        
        public SearchCDs_Advanced_Input()
        {
            Page = -1;
            Filter_isMixed = false;
            SearchCD = new Media_Music_CDs();
        }
    }

}
