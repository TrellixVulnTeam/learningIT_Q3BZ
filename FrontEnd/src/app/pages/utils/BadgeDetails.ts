export class BadgeDetails {
  id: number;
  title: string;
  imageURL: string;
  courseId: number;

  public constructor( id, title, imageURL, courseId){
    this.id = id;
    this.title = title;
    this.imageURL = imageURL;
    this.courseId = courseId;
  }

}
