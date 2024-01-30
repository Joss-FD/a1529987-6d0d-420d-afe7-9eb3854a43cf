import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from  '@angular/common/http';

@Component({
  selector: 'app-root',
  template: `
    <!--The content below is only a placeholder and can be replaced.-->
    <div style="text-align:center">
      <h1>
        Longest Incremental Sequence Finder
      </h1>
      <div class="content">
        <span> Enter a list of numbers seperated by a whitespace </span>
        <textarea placeholder="Enter numbers..." cols="30" rows="10" [value]="inputText" (input)="updateValue($event)"></textarea>
        <button (click)="getLongestSequence()">Find</button>
        <p #output>
        {{inputSnapshot}}
        </p> 
      </div>
    </div>
    
  `,
  styles: []
})
export class AppComponent {

  constructor(private http: HttpClient) {

  }

  @ViewChild('output', {static: true})
  output!: ElementRef;

  title = 'WebView';

  inputText: string = "";
  inputSnapshot: string = "";
  resultSequence: any = "";

  updateValue(e: Event) {
    this.inputText = (e.target as HTMLTextAreaElement).value;
  }

  getLongestSequence() {
    this.inputSnapshot = this.inputText;
    
    this.http.post("https://localhost:7186/FindSequence",  this.inputText.toString(), {responseType: 'text'}).subscribe(res => { 
   
      console.log(res);
      
      this.resultSequence = res.toString();
      this.updateView();
    });
    
  }

  updateView() {

    this.output.nativeElement.innerHTML = this.inputSnapshot.replaceAll(this.resultSequence, `<span id="target" class="highlight"> ${this.resultSequence}</span>`);
    this.scroll()
  }

  scroll() {
    let el: HTMLElement = document.getElementById("target")!;
    console.log(el);
    
    el.scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'});
  }

}
