// Nir Leibovitch 200315232

// surround code with an IEFE so variables & function declarations don't leak to the global object
(function () {
    var margin = { top: 20, right: 20, bottom: 30, left: 40 };

    $.getJSON("/Student/StudentBody", function (data) {
        // wait for DOM ready
        $(document).ready(function () {
            var svg = d3.select("svg");
            var width = +svg.attr("width") - margin.left - margin.right;
            var height = +svg.attr("height") - margin.top - margin.bottom;

            var x = d3.scaleBand().rangeRound([0, width]).padding(0.1);
            var y = d3.scaleLinear().rangeRound([height, 0]);

            var g = svg.append("g")
                .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

            x.domain(data.map(function (d) { return d.EnrollmentYear; }));
            y.domain([0, d3.max(data, function (d) { return d.StudentCount; })]);

            g.append("g")
                .attr("class", "axis axis--x")
                .attr("transform", "translate(0," + height + ")")
                .call(d3.axisBottom(x));

            g.append("g")
                .attr("class", "axis axis--y")
                .call(d3.axisLeft(y).ticks(10))
                .append("text")
                .attr("transform", "rotate(-90)")
                .attr("y", 6)
                .attr("dy", "0.71em")
                .attr("text-anchor", "end")
                .text("Frequency");

            g.selectAll(".bar")
                .data(data)
                .enter().append("rect")
                .attr("class", "bar")
                .attr("x", function (d) { return x(d.EnrollmentYear); })
                .attr("y", function (d) { return y(d.StudentCount); })
                .attr("width", x.bandwidth())
                .attr("height", function (d) { return height - y(d.StudentCount); });
        });
    });
}());