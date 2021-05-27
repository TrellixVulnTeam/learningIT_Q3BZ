export class ChapterDetails {
  id: number;
  title: string;
  content: string;
  time: number;
  flagFinished: number;
  courseId: number;

  public constructor( id, title, content, time, flagFinished, courseId){
    this.id = id;
    this.title = title;
    this.content = content;
    this.time = time;
    this.flagFinished = flagFinished;
    this.courseId = courseId;
  }
}
