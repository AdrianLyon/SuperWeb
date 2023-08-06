app.controller('CategoryListController', function ($scope, $location,categoryService) {
    $scope.categories = [];
    $scope.currentPage = 1;
    $scope.totalPages = 0;
    $scope.searchQuery = '';
    $scope.getCategories = function() {
    categoryService.getCategories($scope.currentPage, 10, $scope.searchQuery).
        then(function (response)
        {
            $scope.categories = response.data.items
            $scope.totalPages = response.data.totalPages;
        })
        .catch(function (error)
        {
            console.error('Error fetching category:', error)
        });
    }
    $scope.changePage = function(page) {
        if (page >= 1 && page <= $scope.totalPages) {
          $scope.currentPage = page;
          $scope.getCategories();
        }
      };
    
    $scope.getCategories();

    $scope.editCategory = function (categoryId) {
        $location.path('/category/edit/' + categoryId); // Navigate to edit page
    };

    $scope.goToCreatePage = function () {
        $location.path('/category/create'); // Navigate to create page
    };
});


