app.service('productService', function ($http) {
    var baseUrl = 'http://localhost:5000/api/products'; 
    return {
        getProducts: function (page, pageSize, searchQuery) {
            return $http.get(baseUrl,{
                params: {
                  page: page,
                  pageSize: pageSize,
                  searchQuery: searchQuery
                }
              })},
        getProduct: function (id) {
            return $http.get(baseUrl + '/' + id);
        },
        createProduct: function (product) {
            return $http.post(baseUrl, product);
        },
        createProduct: function (product) {
            return $http.post(baseUrl, product);
        },
        updateProduct: function (id, product) {
            return $http.put(baseUrl + '/' + id, product);
        },
        deleteProduct: function (id) {
            return $http.delete(baseUrl + '/' + id);
        }
    };
});
