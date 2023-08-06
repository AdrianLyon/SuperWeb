app.controller('CategoryFormController', function ($scope, $routeParams, $location, categoryService) {
    $scope.category = {};

    if ($routeParams.categoryId) {
        // Editing existing product
        categoryService.getCategory($routeParams.categoryId)
            .then(function (response) {
                $scope.category = response.data;
            })
            .catch(function (error) {
                console.error('Error fetching category details:', error);
            });
    }

    $scope.saveCategory = function () {
        if ($routeParams.categoryId) {
            // Update existing product
            categoryService.updateCategory($routeParams.categoryId, $scope.category)
                .then(function () {
                    $location.path('/category');
                })
                .catch(function (error) {
                    console.error('Error updating category:', error);
                });
        } else {
            // Create new product
            categoryService.createCategory($scope.category)
                .then(function () {
                    $location.path('/');
                })
                .catch(function (error) {
                    console.error('Error creating category:', error);
                });
        }
    };

    $scope.deleteProduct = function () {
        categoryService.deleteCategory($routeParams.categoryId)
            .then(function () {
                $location.path('/');
            })
            .catch(function (error) {
                console.error('Error deleting category:', error);
            });
    };
});
