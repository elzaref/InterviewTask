app.service("APIService", function ($http) {
    this.Show = function (userId) {
        return $http.get('/api/request/Get', { params: { "userid": userId } }).then(function (response) {
            return response.data;
        });
    }
    ///////////
    this.saveUser = function (user) {
        return $http(
            {
                method: 'post',
                data: user,
                url: '/api/user'
            });
    }
    ///////
    
    this.ISloged = function (name, password) {
        return $http.get('/api/user/GetuserByName_Password', {
            params: { "name": name, "password": password },
        }).then(function (response) {
            return response.data;
        });
    }
    this.SaveRequest = function (Request) {
        return $http(
            {
                method: 'post',
                data: Request,
                url: '/api/request'
            });
    }
}); 

///////////
