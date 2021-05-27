export class CourseDetails {
  id: number;
  title: string;
  description: string;
  imageURL: string;
  experience: number;
  category: string;
  level: string;
  time: number;


  public constructor( id, title, description, imageURL, experience, category, level, time){
    this.id = id;
    this.title = title;
    this.description = description;
    this.imageURL = imageURL;
    this.experience = experience;
    this.category = category;
    this.level = level;
    this.time = time;
  }
}
