class Report
  attr_reader :title, :text
  attr_accessor :formatter

  def initialize(&formatter)
    @title = "Title"
    @text = ["Great", "Not bad"]
    @formatter = formatter
  end

  def output_report
    @formatter.call self
  end
end

HTML_FORMATTER = ->(context) {
  puts '<html>'
  puts '<body>'
  puts "<p>#{context.title}</p>"
  context.text.each {|line| puts "<p>#{line}</p>" }
  puts '</body>'
  puts '</html>'
}

report = Report.new &HTML_FORMATTER
report.output_report
