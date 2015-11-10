class PersonTest {
    constructor() {
        this._id = -1;
        this.ID = 0;
        this.Name = '';
        this._id = 123;
        this.Name = 'Bob';
    }
    ;
    DoWork(input) {
        var _person = new PersonTest();
        _person.ID = 123;
        _person.Name = "Kevin" + input;
        var _cast = _person;
        return _person;
    }
    MoreWork(input) {
        return input.toString();
    }
}
//# sourceMappingURL=Person.js.map