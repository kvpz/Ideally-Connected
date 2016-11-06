var body = d3.select("body");
var duration = 2000;
body.append("div") // <-A
        .classed("box", true)
        .style("background-color", "#e9967a") // <-B
    .transition() // <-C
    .duration(duration) // <-D
        .style("background-color", "#add8e6") // <-E
        .style("margin-left", "600px") // <-F
        .style("width", "100px")
        .style("height", "100px");