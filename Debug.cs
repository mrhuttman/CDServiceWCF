using System.Text;

public class Debug
{
    public string printCDParams(DAO.Media_Music_CDs CD)
    {        
        StringBuilder sb = new StringBuilder();                
        sb.AppendLine("itemNo_pk: " + CD.itemNo_pk.ToString());
        sb.AppendLine("Artist: " + CD.Artist);
        sb.AppendLine("Title: " + CD.Title);
        sb.AppendLine("isMixed: " + CD.isMixed.ToString());
        sb.AppendLine("isSingle: " + CD.isSingle.ToString());
        sb.AppendLine("imageUrl_lg: " + CD.imageUrl_lg);
        sb.AppendLine("imageUrl_sm: " + CD.imageUrl_sm);
        sb.AppendLine("binder: " + CD.binder.ToString());
        sb.AppendLine("numDiscs: " + CD.numDiscs.ToString());
        sb.AppendLine("misc: " + CD.misc);
        return sb.ToString();        
    }
}

