namespace Application
{
    public static class Utility
    {
        public static Tuple<string, string, string>? getSplitRMHId(string rmh_id)
        {
            if (!string.IsNullOrEmpty(rmh_id))
            {
                var key_arr = rmh_id.Split('#');
                if (!string.IsNullOrEmpty(key_arr[0]))
                    return new Tuple<string, string, string>(key_arr[0], key_arr[1] ?? "", key_arr[2] ?? "");
                else
                {
                    throw new ArgumentException();
                }
            }
            return null;
        }
    }
}
