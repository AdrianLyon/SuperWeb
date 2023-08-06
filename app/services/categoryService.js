app.service('categoryService', function ($http) {
    var baseUrl = 'http://localhost:5000/api/categories'; // Replace with your API URL

    return {
        getCategories: function (page, pageSize, searchQuery) {
            return $http.get(baseUrl,{
                params: {
                  page: page,
                  pageSize: pageSize,
                  searchQuery: searchQuery
                }
              })},
        getCategory: function (id) {
            return $http.get(baseUrl + '/' + id);
        },
        createCategory: function (category) {
            return $http.post(baseUrl, category);
        },
        updateCategory: function (id, category) {
            return $http.put(baseUrl + '/' + id, category);
        },
        deleteCategory: function (id) {
            return $http.delete(baseUrl + '/' + id);
        }
    };
});
