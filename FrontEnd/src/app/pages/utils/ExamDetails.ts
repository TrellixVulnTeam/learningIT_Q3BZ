export class ExamDetalis {

  id: number;
  title: string;
  content: string;
  points: number;
  courseId: number;

  public constructor( id, title, content, points, courseId, category, level, time){
    this.id = id;
    this.title = title;
    this.content = content;
    this.points = points;
    this.courseId = courseId;
  }

}
