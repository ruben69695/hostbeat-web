export function highlightSnippet(){
    document.querySelectorAll('pre code').forEach((el)=>{
        hljs.highlightBlock(el);
    });
}