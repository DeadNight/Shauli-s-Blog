// Nir Leibovitch 200315232

// surround code with an IEFE so variables & function declarations don't leak to the global object
(function () {
    var diameter = 960;
    var employees;
    var root;
    var makeTree;

    // first, get the employees data (even though the DOM is probably not ready yet)
    $.getJSON('/Content/employees.json', function (data) {
        // the data is ready, wait for DOM ready
        $(document).ready(function () {
            // the DOM is ready, we can start manipulating it
            employees = data;
            init();
        });
    });

    // utility functions
    // -----------------

    function init() {
        // setup callbacks
        $('.back').click(backClick);
        $('.slider').show().on('input', sliderInput);

        // setup svg
        d3.select('.chart')
            .attr('width', diameter)
            .attr('height', diameter)
            .append('g')
                .attr('transform', 'translate(' + diameter / 2 + ',' + diameter / 2 + ')');

        // create a helper function to transform the chart data
        makeTree = d3.tree()
            .size([360, diameter / 2 - 120])
            .separation(function (a, b) { return (a.parent == b.parent ? 1 : 2) / a.depth; });

        // create a hierarchical data structure and set it as the initial root of the chart
        switchRoot(d3.hierarchy(employees));
    }

    // back button click handler
    function backClick(event) {
        if (!root.parent)
            return;
        switchRoot(root.parent);
    }

    /* slider input handler (fired when the value was changed, even if not committed yet)
     * Note:
     *  According to the task requirements, the forward movement is calculated by the first child.
     *  This means that if the current node isn't a first child, and the user is going back, an apparent "glitch" will be seen:
     *  - The new max depth may be different (which may cause the current depth to change according to the mouse position)
     *  - Moving forward will go the the first child instead of the previous seen node, which may cause confusion
     */
    function sliderInput(event) {
        var value = $(this).val();
        var depth = currentDepth();
        if (value < depth)
            switchRoot(root.parent);
        else if (value > depth)
            switchRoot(root.children[0]);
    }

    // node click handler
    function nodeClick(data, index) {
        if (!data)
            return;
        switchRoot(data);
    }

    // set the new root of the chart
    function switchRoot(newRoot) {
        root = newRoot;
        makeTree(root);
        updateRange();
        drawOrgChart();
    }

    // update the slider current & max depth
    function updateRange() {
        // find the current depth
        var value = currentDepth();

        // find the max depth
        var node = root;
        var max = value;
        while (node.children && (node = node.children[0]))++max;

        // set the slider current & max depth
        $('.slider').attr({ max: max, value: value }).val(value);
    }

    // get the depth of the current root of the chart
    function currentDepth() {
        var node = root;
        var value = 0;
        while ((node = node.parent))++value;
        return value;
    }

    // draw the organiztion chart
    function drawOrgChart() {
        // show the back button only if the current root has a parent
        $('.back').toggle(root.parent != null);

        var svg = d3.select('.chart').select('g');
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
                .attr('transform', function (d) { return 'translate(' + project(d.x, d.y) + ')'; })
                .on('click', nodeClick);

        node.append('circle')
            .attr('r', 4);

        node.append('text')
            .attr('dy', '.31em')
            .attr('x', function (d) { return d.x < 180 === !d.children ? 6 : -6; })
            .style('text-anchor', function (d) { return d.x < 180 === !d.children ? 'start' : 'end'; })
            .attr('transform', function (d) { return 'rotate(' + (d.x < 180 ? d.x - 90 : d.x + 90) + ')'; })
            .text(function (d) { return d.data.name; });
    }

    // helper function used for calculating the arguments for the SVG CurveTo command for creating the links
    function project(x, y) {
        var angle = (x - 90) / 180 * Math.PI, radius = y;
        return [radius * Math.cos(angle), radius * Math.sin(angle)];
    }
}());