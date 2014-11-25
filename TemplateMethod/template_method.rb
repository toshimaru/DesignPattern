class Report
  def initialize
    @title = "Title"
    @text = ["Great.", "awesome!"]
  end

  def output_report
    output_start
    output_body
    output_end
  end

  def output_body
    @text.each do |line|
      output_line(line)
    end
  end

  def output_start
    raise "abstract method: output_start"
  end

  def output_line(line)
    raise "abstract method: output_line"
  end

  def output_end
    raise "abstract method: output_end"
  end
end

class HtmlReport < Report
  def output_start
    puts "<html>"
    puts "<body>"
    puts "<h1>#{@title}</h1>"
  end

  def output_line(line)
    puts "<p>#{line}</p>"
  end

  def output_end
    puts "</body>"
    puts "</html>"
  end
end

class PlainReport < Report
  def output_start
    puts "*** #{@title} ****"
  end

  def output_line(line)
    puts "- #{line}"
  end

  def output_end
  end
end

HtmlReport.new().output_report
puts
PlainReport.new().output_report
