namespace AppNotes.Models.Core;
public static class JsDateEncoder
{
    static readonly string jsTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

    public static string JsDate(DateTime date) => date.ToString(jsTimeFormat);
}