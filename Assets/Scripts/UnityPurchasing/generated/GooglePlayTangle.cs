// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("mHrl2MIC+Mv1lVnSVoZGOfprAsY30z7jc8ldOcWfEdnJWGrW7pHSJ9CdRUbXC22TPHNNe5g36A6FXp0XXAdvZFSEYxtE0Xi65M4nAbK2gqb6gYkCY1NzuKO6ASxkJdlBOOPsLNQJ8szfWwiKV8AUaxlR4hYWz0/h0zZ0quhwmZ9dj4pyIPPfy9iS1sX0PMXA8ip0pD+LTL4tzc+Qgxc+fjWHBCc1CAMML4NNg/IIBAQEAAUGvOgfBD9p4GcypZdfL8SyqaXInojhOcInNcDo0+h8fO9npNjg19gtPuCTE/QY4e34EBDUW9zzK+yaHYlphwQKBTWHBA8HhwQEBYrxtvW8fg4PMAoWEUF/BeA7uaptJpet1Fe/2tvYlnzc0LFgsAcGBAUE");
        private static int[] order = new int[] { 9,6,11,10,10,11,7,10,9,12,13,12,13,13,14 };
        private static int key = 5;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
