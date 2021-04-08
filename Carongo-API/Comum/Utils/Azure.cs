using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comum.Utils
{
    class FaceAluno
    {
        public Guid FaceId { get; set; }
        public string UrlImagem { get; set; }

        public FaceAluno(Guid f, string u)
        {
            FaceId = f;
            UrlImagem = u;
        }
    }

    public static class Azure
    {
        const string KEY = "";
        const string ENDPOINT = "";

        private static IFaceClient Autenticar(string endpoint, string key)
        {
            return new FaceClient(new ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        private static async Task<List<DetectedFace>> DetectFaceRecognize(IFaceClient faceClient, string url, string recognition_model)
        {
            IList<DetectedFace> detectedFaces = await faceClient.Face.DetectWithUrlAsync(url, recognitionModel: recognition_model, detectionModel: DetectionModel.Detection02);
            return detectedFaces.ToList();
        }

        public static async Task<string> FindSimilar(string urlImagemOrigem, string recognition_model, List<string> urlsImagensDestino)
        {
            var client = Autenticar(ENDPOINT, KEY);

            IList<Guid?> facesDestinoIds = new List<Guid?>();
            List<FaceAluno> facesIdsUrlsImagens = new List<FaceAluno>();

            foreach (var urlImagemDestino in urlsImagensDestino)
            {
                var faces = await DetectFaceRecognize(client, urlImagemDestino, recognition_model);
                facesDestinoIds.Add(faces[0].FaceId.Value);

                facesIdsUrlsImagens.Add(new FaceAluno(faces[0].FaceId.Value, urlImagemDestino));
            }

            IList<DetectedFace> detectedFaces = await DetectFaceRecognize(client, urlImagemOrigem, recognition_model);

            IList<SimilarFace> similarResults = await client.Face.FindSimilarAsync(detectedFaces[0].FaceId.Value, null, null, facesDestinoIds);

            string urlImagemDoAlunoParecido = null;

            if(similarResults.Count > 0)
            {
                urlImagemDoAlunoParecido = similarResults[0].Confidence > 0.5 ? facesIdsUrlsImagens.Find(fa => fa.FaceId == similarResults[0].FaceId).UrlImagem : null;
            }
            
            return urlImagemDoAlunoParecido;
        }
    }
}