export class QuestionDetails {

  id: number;
  description: string;
  raspunsA: string;
  raspunsB: string;
  raspunsC: string;
  raspunsD: string;
  raspunsCorect: number;

  public constructor (id, description, raspunsA, raspunsB, raspunsC, raspunsD, raspunsCorect) {

    this.id = id;
    this.description = description;
    this.raspunsA = raspunsA;
    this.raspunsB = raspunsB;
    this.raspunsC = raspunsC;
    this.raspunsD = raspunsD;
    this.raspunsCorect = raspunsCorect;

  }

}
