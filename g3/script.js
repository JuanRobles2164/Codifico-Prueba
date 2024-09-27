d3.select("#updateDataBtn").on("click", function() {
    const data = document.getElementById("sourceData").value.split(',').map(Number);
    const color = d3.scaleOrdinal(d3.schemeCategory10);
  
    const bars = d3.select("#chart")
      .selectAll("rect")
      .data(data);
  
    bars.enter()
      .append("rect")
      .merge(bars)
      .attr("width", 40)
      .attr("height", d => d * 10)
      .attr("x", (d, i) => i * 50)
      .attr("fill", (d, i) => color(i));
  
    bars.exit().remove();
  });
  