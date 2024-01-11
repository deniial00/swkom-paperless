// using NPaperless.SA.Interfaces;

// using Elasticsearch.Net;

// namespace NPaperless.SA;

// public class ElasticSearchService : IElasticSearchService
// {
// 	private readonly ElasticLowLevelClient _elasticSearchClient;
// 	ElasticSearchService() {
// 		var settings = new ConnectionSettings(new Uri(elasticSearchUrl))
// 			.CertificateFingerprint(elasticFingerprint)
// 			.BasicAuthentication(elasticUsername, elasticPassword)
// 			.DefaultIndex("swkom-index")
// 			.EnableApiVersioningHeader();
// 		_client = new ElasticClient(settings);
// 	}

// 	public Task<bool> IndexDocumentAsync() {

// 	}

// 	public Task<bool> SearchInDocumentsAsync() {

// 	}
// }
