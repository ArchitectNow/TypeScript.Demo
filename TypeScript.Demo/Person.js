var PersonTest = (function () {
    function PersonTest() {
        this._id = -1;
        this.ID = 0;
        this.Name = '';
        this._id = 123;
        this.Name = 'Bob';
    }
    ;
    PersonTest.prototype.DoWork = function (input) {
        var _person = new PersonTest();
        _person.ID = 123;
        _person.Name = "Kevin" + input;
        var _cast = _person;
        return _person;
    };
    PersonTest.prototype.MoreWork = function (input) {
        return input.toString();
    };
    return PersonTest;
})();
//# sourceMappingURL=Person.js.map