interface IPerson {
    ID: number;
    Name: string;
    Parent: IPerson;
}

class PersonTest implements IPerson {

    constructor() {
        
        this._id = 123;
        this.Name = 'Bob';

    };

    Parent: IPerson;

    private _id : number = -1;

    public ID: number = 0;
    public Name = '';

    public anytype: any;


    public DoWork(input: string): IPerson {

        var _person: IPerson = new PersonTest();

        _person.ID = 123;
        _person.Name = "Kevin" + input;

        var _cast = <PersonTest>_person;

   
        
        return _person;

    }

    private MoreWork(input: number): string {

        return input.toString();
    }

}