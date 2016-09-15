// Nir Leibovitch 200315232

// surround code with an IEFE so variables & function declarations don't leak to the global object
(function () {
    var diameter = 800;

    $.getJSON("/Department/Organization", function (data) {
        // wait for DOM ready
        $(document).ready(function () {
            
            var svg = d3.select('#orgChart')
                .attr('width', diameter)
                .attr('height', diameter)
                .append('g')
                    .attr('transform', 'translate(' + diameter / 2 + ',' + diameter / 2 + ')');

            // create a helper function to transform the chart data
            var makeTree = d3.tree()
                .size([360, diameter / 2 - 120])
                .separation(function (a, b) { return (a.parent == b.parent ? 1 : 2) / a.depth; });

            // create a hierarchical data structure and set it as the initial root of the chart
            var root = d3.hierarchy(data);
            makeTree(root);
            
            // clear the chart
            svg.selectAll('*').remove();

            // create all links between nodes
            var link = svg.selectAll('.link')
                .data(root.descendants().slice(1))
                .enter().append('path')
                    .attr('class', 'link')
                    .attr('d', function (d) {
                        return 'M' + project(d.x, d.y)
                            + 'C' + project(d.x, (d.y + d.parent.y) / 2)
                            + ' ' + project(d.parent.x, (d.y + d.parent.y) / 2)
                            + ' ' + project(d.parent.x, d.parent.y);
                    });

            // create all nodes
            var node = svg.selectAll('.node')
                .data(root.descendants())
                .enter().append('g')
                    .attr('class', function (d) { return 'node' + (d.children ? ' node--internal' : ' node--leaf'); })
                    .attr('transform', function (d) { return 'translate(' + project(d.x, d.y) + ')'; });

            node.append('circle')
                .attr('r', 4);

            node.append('text')
                .attr('dy', '.31em')
                .attr('x', function (d) { return d.x < 180 === !d.children ? 6 : -6; })
                .style('text-anchor', function (d) { return d.x < 180 === !d.children ? 'start' : 'end'; })
                .attr('transform', function (d) { return 'rotate(' + (d.x < 180 ? d.x - 90 : d.x + 90) + ')'; })
                .text(function (d) { return d.data.name; });
        });
    });

    function project(x, y) {
        var angle = (x - 90) / 180 * Math.PI, radius = y;
        return [radius * Math.cos(angle), radius * Math.sin(angle)];
    }
}());