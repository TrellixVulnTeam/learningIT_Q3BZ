export class CertificatModel {
  numeUser: string;
  numeCurs: string;
  imageCurs: string;

  public constructor( numeUser, numeCurs, imageCurs){
    this.numeUser = numeUser;
    this.numeCurs = numeCurs;
    this.imageCurs = imageCurs;
  }
}
