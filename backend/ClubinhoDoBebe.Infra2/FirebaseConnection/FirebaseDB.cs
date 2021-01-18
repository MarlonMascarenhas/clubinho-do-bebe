using ClubinhoDoBebe.Infra.FirebaseConnection;
using System.Net.Http;

namespace ClubinhoDoBebe.Infra
{
    public class FirebaseDB
    {
        public FirebaseDB(string baseURL)
        {
            this.RootNode = baseURL;
        }

        private string RootNode { get; set; }

        public FirebaseDB Node(string node)
        {

            return new FirebaseDB(this.RootNode + '/' + node);
        }

        public FirebaseDB NodePath(string nodePath)
        {
            return new FirebaseDB(this.RootNode + '/' + nodePath);
        }

        public FirebaseResponse Get()
        {
            return new FirebaseRequest(HttpMethod.Get, this.RootNode).Execute();
        }

        public FirebaseResponse Put(string jsonData)
        {
            return new FirebaseRequest(HttpMethod.Put, this.RootNode, jsonData).Execute();
        }

        public FirebaseResponse Post(string jsonData)
        {
            return new FirebaseRequest(HttpMethod.Post, this.RootNode, jsonData).Execute();
        }

        public FirebaseResponse Patch(string jsonData)
        {
            return new FirebaseRequest(new HttpMethod("PATCH"), this.RootNode, jsonData).Execute();
        }

        public FirebaseResponse Delete()
        {
            return new FirebaseRequest(HttpMethod.Delete, this.RootNode).Execute();
        }

        public override string ToString()
        {
            return this.RootNode;
        }
    }
}
