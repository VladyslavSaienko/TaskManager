var ViewModel = function () {
    var self = this;
    self.users = ko.observableArray();
    self.tasks = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    self.newUser = {
        Name: ko.observable()
    }

    self.getTaskDetail = function (item) {
        ajaxHelper(tasksUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
    self.getTaskDelete = function (item) {
        ajaxHelper(tasksUri + item.Id, 'DELETE').done(function (data) {
            self.tasks.remove(data);
            getAllTasks();

        });
    }
    
    self.newTask = {
        Name: ko.observable(),
        Author: ko.observable(),
        Executor: ko.observable(),
        Status: ko.observable(),
        Description: ko.observable()
    }
    
    var tasksUri = '/api/tasks/';
    var usersUri = '/api/users/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    self.addTask = function () {
        var task = {

            UserId: self.newTask.Author().Id,
            Name: self.newTask.Name(),
            Executor: self.newTask.Executor(),
            Status: self.newTask.Status(),
            Description: self.newTask.Description()
        };

        ajaxHelper(tasksUri, 'POST', task).done(function (item) {
            self.tasks.push(item);
        });
    }
    
    self.addUser = function () {
        var user = {
            Name: self.newUser.Name()
        };

        ajaxHelper(usersUri, 'POST', user).done(function (item) {
            self.users.push(item);
        });
    }
    
    function getAllUsers() {
        ajaxHelper(usersUri, 'GET').done(function (data) {
            self.users(data);
        });
    }

    function getAllTasks() {
        ajaxHelper(tasksUri, 'GET').done(function (data) {
            self.tasks(data);
        });
    }

  

    getAllUsers();
    getAllTasks();

};

ko.applyBindings(new ViewModel());