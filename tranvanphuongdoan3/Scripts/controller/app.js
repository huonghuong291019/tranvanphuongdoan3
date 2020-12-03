var app = angular.module('myapp', []);

app.controller('sanphamCtrl', sanphamCtrl);

sanphamCtrl.$inject = ["$scope", "$http"];

function sanphamCtrl($scope, $http) {

    $scope.listsanpham;

    function getsanpham() {
        debugger
        $http({
            method: 'GET',
            url: '/nhan/sanpham',
        }).then(function (result) {
            $scope.listsanpham = result.data;
            console.log(result.data);
        }, function (error) {
            console.log(error);
            console.log('looi');
        });
    }

    getsanpham();

}