using System.Text;

public static class Debug
{
    public static string printCDParams(DAO.Media_Music_CDs CD)
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
        sb.AppendLine("Genre: " + CD.Genre);
        return sb.ToString();
    }
}



